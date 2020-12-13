import { get, post, del, put } from './requester.js';

let idEditBook;
const collection = "books";
const projectId = "books-46379";

const elements = {
    $loadBooksBtn: () => document.getElementById('loadBooks'),
    $tbody: () => document.querySelector('body > table > tbody'),
    $createForm: () => document.getElementById('create-form'),
    $submitBtn: () => document.querySelector('body > form > button'),
    $editForm: () => document.getElementById('edit-form'),
    $editSubmitBtn: () => document.getElementById('edit-submit'),
};

elements.$loadBooksBtn().addEventListener('click', loadBooks);
elements.$submitBtn().addEventListener('click', createBook);

function loadBooks(event) {
    event.preventDefault();
    cleaner();
    getAllBooks();

    function getAllBooks() {
        get(projectId, collection)
            .then((books) => showBooks(books))
            .catch((err) => alert(err));
    }

    function showBooks(books) {
        for (const book of Object.entries(books)) {
            const bookId = book[0];
            const bookInfo = book[1];
            createTr(bookInfo, bookId);
        }
    }
}

function deleteBook(event) {
    event.preventDefault();
    const idDeleteBook = getId();
    removeBookFromServer();
    removeBookFromPage();
    
    function removeBookFromServer() {
        del(projectId, collection, idDeleteBook);
    }
    
    function removeBookFromPage() {
        event.currentTarget.parentNode.parentNode.remove();
    }

    function getId() {
        return event.currentTarget.parentNode.parentNode.getAttribute('data-id');
    }
}

function editBook(event) {
    event.preventDefault();
    fromBookInputsToEditInputs();
    whenEditButtonIsClick();

    function whenEditButtonIsClick() {
        elements.$editSubmitBtn().addEventListener('click', (e) => {
            e.preventDefault();
            const data = getData([...elements.$editForm().children], 5);
            const check = checkEmptyValues(data);
            if (check !== '') {
                const row = removeOldBook();
                loadEditBook(data, row);
            }
            clearInputs();
        });

        function loadEditBook(data, row) {
            put(projectId, collection, data, idEditBook)
                .then(newBook => showEditBook(newBook, row))
                .catch((err) => alert(err));
        }

        function showEditBook(newBook, row) {
            createTr(newBook, idEditBook, row);
        }

        function removeOldBook() {
            const oldBookForEdit = [...elements.$tbody().children].find(x => x.dataset.id === idEditBook);
            const row = oldBookForEdit.rowIndex - 1;
            oldBookForEdit.remove();
            return row;
        }
    }

    function fromBookInputsToEditInputs() {
        idEditBook = event.currentTarget.parentNode.parentNode.getAttribute('data-id');
        let editInputs = [...elements.$editForm().children].filter(t => t.tagName === 'INPUT');
        let bookInputs = [...event.currentTarget.parentNode.parentNode.children].filter(t => t.tagName === 'TD');
        for (let i = 0; i < editInputs.length; i++) {
            editInputs[i].value = bookInputs[i].textContent;
        }
    }
}

function createBook(event) {
    event.preventDefault();
    const data = getData([...elements.$createForm().children], 7);
    const check = checkEmptyValues(data);
    if (check !== '') {
        loadCreateBook();
    }
    clearInputs();

    function loadCreateBook() {
        post(projectId, collection, data)
            .then((book) => showCreateBook(book));
    }

    function showCreateBook(book) {
        createTr(data, book);
    }
}

function createTr(book, id, row = -1) {
    const { title, author, isbn } = book;
    const tr = elements.$tbody().insertRow(row);
    tr.setAttribute('data-id', id);
    createTd(tr, title);
    createTd(tr, author);
    createTd(tr, isbn);
    createTd(tr);

    function createTd(tr, textName) {
        const td = tr.insertCell(-1);
        if (textName) {
            td.textContent = textName;
        } else {
            createBtn('Edit', editBook, td);
            createBtn('Delete', deleteBook, td);
        }
    }

    function createBtn(textContent, func, td) {
        let button = document.createElement('button');
        button.textContent = textContent;
        button.addEventListener('click', func);
        td.append(button);
    }
}

function checkEmptyValues(data) {
    return Object.values(data).find(x => x === '');
}

function getData(form, index) {
    return form
        .filter(t => t.tagName === 'INPUT')
        .reduce((acc, curr) => {
            acc[curr.id.slice(index)] = curr.value;
            return acc;
        }, {});
}

function cleaner() {
    elements.$tbody().innerHTML = '';
}

function clearInputs() {
    [...document.getElementsByTagName('input')].forEach((e) => e.value = '');
}