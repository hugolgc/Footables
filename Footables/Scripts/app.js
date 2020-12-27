$(() => {

    const home = new Swiper('#homeSlider')
    
    if ($('#playerChange').length) {
        var displayText = false
        $('#playerChange').click(() => {
            if (displayText) {
                displayText = false
                $('#playerChange').html('VOIR AU FORMAT TEXTE')
                $('#radarContainer').attr('class', 'p-8 bg-grey-bis')
                $('#playerStats').attr('class', 'hidden')
            } else {
                displayText = true
                $('#playerChange').html('VOIR LE GRAPHIQUE')
                $('#radarContainer').attr('class', 'hidden')
                $('#playerStats').attr('class', 'block')
            }
        })
    }

    $.get('/Equipes/Classement', data => {
        $('#ranking').html('')
        data.map(equipe => {
            $('#ranking').append(`
                <a href="/Equipes/Details/${equipe.Id}">
                    <article class="py-2 flex justify-between items-center">
                        <div class="flex items-center">
                            <img src="${equipe.Figure}" alt="Logo ${equipe.Nom}" class="h-6 w-6 mr-3">
                            <h3 class="text-white font-light">${equipe.Nom}</h3>
                        </div>
                        <p class="text-white-bis">${equipe.Points}</p>
                    </article>
                </a>
            `)
        })
    })


    var joueurs = null
    $.get('/Joueurs/Liste', data => { joueurs = data })

    $('#search').keyup(() => {
        if ($('#search').val()) {
            var i = 0
            var results = joueurs.filter(joueur => joueur.Nom.includes($('#search').val()));
            $('#resultsJoueurs').html('')
            if (results.length > 0) {
                results.map(joueur => {
                    i++; if (i > 5) return false
                    $('#resultsJoueurs').append(`
                    <li>
                        <a href="/Joueurs/Details/${joueur.Id}" class="block flex items-center py-1">
                            <img src="${joueur.Figure}" alt="Logo ${joueur.Nom}" class="h-6 w-6 mr-3">
                            <h3 class="text-white font-light">${joueur.Nom}</h3>
                        </a>
                    </li>
                `)
                })
                $('#searchContainer').attr('class', 'absolute top-12 left-0 right-0 bg-grey-darker border border-grey divide-y divide-gray-700 rounded-lg shadow-2xl')
            } else $('#searchContainer').attr('class', 'hidden')
        } else $('#searchContainer').attr('class', 'hidden')
    })

})