import { get, post } from "./requester.js"; // Open together with requester

const collection = "students";
const projectId = "students-632fb";

const elements = {
    $submitBtn: () => document.getElementById('createBtn-submit'),
    $tbody: () => document.querySelector('#results > tbody'),
    $form: () => document.getElementById('form'),
};

loadStudents('');
elements.$submitBtn().addEventListener('click', createStudent);

async function loadStudents(e) {
    cleaner();
    if (e) {
        e.preventDefault();
    }
    try {
        const students = await get(projectId, collection);
        let sortedStudents = Object.entries(students).sort(compare);
        for (const student of sortedStudents) {
            createTr(student[1], student[0]);
        }
    } catch (error) {
        alert(error);
    }

    function createTr(student, _id) {
        const { id, firstName, lastName, facultyNumber, grade } = student;
        const tr = elements.$tbody().insertRow(-1);
        tr.setAttribute('data-id', _id);
        createTd(tr, id);
        createTd(tr, firstName);
        createTd(tr, lastName);
        createTd(tr, facultyNumber);
        createTd(tr, grade);

        function createTd(tr, textName) {
            const td = tr.insertCell(-1);
            td.textContent = textName;
        }
    }
}

async function createStudent(e) {
    e.preventDefault();
    const data = getData();
    const check = checkEmptyValues(data);
    if (check !== '') {
        try {
            await post(projectId, collection, data);
            loadStudents(e);
        } catch (error) {
            alert(error);
        }
    } else {
        alert('Fill the empty inputs and try again, please..!');
        cleaner();
    }

    function checkEmptyValues(data) {
        return Object.values(data).find(x => x === '');
    }

    function getData() {
        return [...elements.$form().children]
            .filter(t => t.tagName === 'INPUT')
            .reduce((acc, curr) => {
                acc[curr.id] = curr.value;
                return acc;
            }, {});
    }
}

function compare(a, b) {
    if (parseInt(a[1].id) < parseInt(b[1].id)) {
        return -1;
    }
    if (parseInt(a[1].id) > parseInt(b[1].id)) {
        return 1;
    }
    return 0;
}

function cleaner() {
    elements.$tbody().innerHTML = '';
    [...document.getElementsByTagName('input')].forEach(e => e.value = '');
}