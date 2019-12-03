class Forum {
    constructor() {
        this._users = [];
        this._questions = [];
        this._id = 1;
    }

    register(username, password, repeatPassword, email) {
        if (!username || !password || !repeatPassword || !email) {
            throw new Error("Input can not be empty");
        }
        if (password !== repeatPassword) {
            throw new Error("Passwords do not match");
        }
        if (this._users.find(u => u.username === username) || this._users.find(u => u.email === email)) {
            throw new Error("This user already exists!");
        }

        let newUser = {
            username,
            password,
            email,
            login: false
        };
        this._users.push(newUser);

        return `${username} with ${email} was registered successfully!`;
    }

    login(username, password) {
        let user = this._users.find(u => u.username === username);
        if (!user) {
            throw new Error("There is no such user");
        }
        if (user.password === password) {
            user.login = true;

            return "Hello! You have logged in successfully";
        }
    }

    logout(username, password) {
        let user = this._users.find(u => u.username === username);
        if (!user) {
            throw new Error("There is no such user");
        }
        if (user.password === password) {
            user.login = false;
            return "You have logged out successfully";
        }
    }

    postQuestion(username, question) {
        let user = this._users.find(u => u.username === username);
        if (!user || user.login === false) {
            throw new Error("You should be logged in to post questions");
        }
        if (question === '') {
            throw new Error("Invalid question");
        }

        let newQuestion = {
            username,
            question,
            id: this._id++,
            answer: []
        };
        this._questions.push(newQuestion);

        return "Your question has been posted successfully";
    }

    postAnswer(username, questionId, answer) {
        let user = this._users.find(u => u.username === username);
        if (!user || user.login === false) {
            throw new Error("You should be logged in to post answers");
        }
        if (answer === '') {
            throw new Error("Invalid answer");
        }

        let id = this._questions.find(u => u.id === questionId);
        if (!id) {
            throw new Error("There is no such question");
        }

        let answerForQuestion = {
            username,
            answer
        };
        id.answer.push(answerForQuestion);

        return "Your answer has been posted successfully";
    }

    showQuestions() {
        return this._questions
        .map(q => `Question ${q.id} by ${q.username}: ${q.question}\n${q.answer
        .map(a => `---${a.username}: ${a.answer}`)
        .join('\n')}`)
        .join('\n');
    }
}

let forum = new Forum();

forum.register('Jonny', '12345', '12345', 'jonny@abv.bg');
forum.register('Peter', '123ab7', '123ab7', 'peter@gmail@.com');
forum.login('Jonny', '12345');
forum.login('Peter', '123ab7');

forum.postQuestion('Jonny', "Do I need glasses for skiing?");
forum.postAnswer('Peter', 1, "Yes, I have rented one last year.");
forum.postAnswer('Jonny', 1, "What was your budget");
forum.postAnswer('Peter', 1, "$50");
forum.postAnswer('Jonny', 1, "Thank you :)");

console.log(forum.showQuestions());