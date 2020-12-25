$(() => {

    const slider = new Swiper('.swiper-container')

    $.get('/Equipes/Ranking', data => {
        $('#ranking').html('')
        data.map(equipe => {
            $('#ranking').append(`
                <a href="/Equipes/Details/${ equipe.Id }">
                    <article class="py-2 flex justify-between items-center">
                        <div class="flex items-center">
                            <img src="${ equipe.Figure }" alt="Logo ${ equipe.Nom }" class="h-6 w-6 mr-3">
                            <h3 class="text-white font-light">${ equipe.Nom }</h3>
                        </div>
                        <p class="text-white-bis">${ equipe.Points }</p>
                    </article>
                </a>
            `)
        })
    })

})