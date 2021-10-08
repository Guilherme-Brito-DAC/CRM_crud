async function getDados(url = '') {
    const response = await fetch(url, {
        method: 'GET',
        mode: 'cors',
        cache: 'no-cache',
        credentials: 'same-origin',
        headers: {
            'Content-Type': 'application/json'
        },
        redirect: 'follow',
        referrerPolicy: 'no-referrer',
    });
    return response.json();
}

getDados('https://localhost:44303/Lead/ListarLeads')
    .then(dados => {
        var select = document.getElementById("leadSelect");

        dados.forEach(lead => {
            var opt = document.createElement('option');
            opt.value = lead.id;
            opt.innerHTML = lead.nome;
            select.appendChild(opt);
        });
    });

getDados('https://localhost:44303/Curso/ListarCursos')
    .then(dados => {
        console.log(dados);
        
        var select = document.getElementById("cursoSelect");

        dados.forEach(curso => {
            var opt = document.createElement('option');
            opt.value = curso.id;
            opt.innerHTML = curso.titulo;
            select.appendChild(opt);
        });
    });