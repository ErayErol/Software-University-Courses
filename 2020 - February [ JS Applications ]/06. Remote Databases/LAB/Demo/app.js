const run = async () => {
    const url = 'https://testapp-fc138.firebaseio.com/books.json';
    const response = await fetch(url);
    const books = await response.json();
    console.log(books);
};

run();