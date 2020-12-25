$(() => {

    const slider = new Swiper('.swiper-container')

    $.get('/Equipes/Ranking', data => {
        $('#ranking').html('')
        data.map(equipe => {
            $('#ranking').append(`
                <article class="py-2 flex justify-between items-center">
                    <div class="flex items-center">
                        <img src="${ equipe.figure }" alt="Logo ${ equipe.nom }" class="h-6 w-6 mr-3">
                        <h3 class="text-white font-light">${ equipe.nom }</h3>
                    </div>
                    <p class="text-white-bis">${ equipe.points }</p>
                </article>
            `)
        })
    })

})