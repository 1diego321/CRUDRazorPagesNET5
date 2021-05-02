var itemMovies = document.querySelectorAll(".movie_item");

itemMovies.forEach(x => {
    x.addEventListener('click', function (e) {
        let id = e.target.parentElement.querySelector("#hidden").value;

        window.location.href = "Movies/Details?id="+id;
    })
});