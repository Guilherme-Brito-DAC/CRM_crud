async function postData(url = '') {
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

postData('https://localhost:44303/Lead/ListarLeads')
    .then(data => {
        console.log(data);
    });

postData('https://localhost:44303/Curso/ListarCursos')
    .then(data => {
        console.log(data);
    });