class Forum {
    constructor() {
        this._users = [];
        this._questions = [];
        this._id = 1;
    }

    register(username, password, repeatPassword, email) {
        const sameUsername = this._users.find(u => u.username === username);
        const sameEmail = this._users.find(u => u.email === email);
        const user = { username, password, password, email, login: false };
        if (!username || !password || !repeatPassword || !email) {
            throw new Error("Input can not be empty");
        }
        if (password !== repeatPassword) {
            throw new Error("Passwords do not match");
        }
        if (sameUsername || sameEmail) {
            throw new Error("This user already exists!");
        }
        this._users.push(user);
        return `${username} with ${email} was registered successfully!`;
    }

    login(username, password) {
        const user = this._users.find(u => u.username === username);
        if (!user) {
            throw new Error("There is no such user");
        }
        if (user.password === password) {
            user.login = true;
            return "Hello! You have logged in successfully";
        }
    }

    logout(username, password) {
        const user = this._users.find(u => u.username === username);
        if (!user) {
            throw new Error("There is no such user");
        }
        if (user.password === password) {
            user.login = false;
            return "You have logged out successfully";
        }
    }

    postQuestion(username, question) {
        const user = this._users.find(u => u.username === username);
        const currQuestion = { id: this._id++, username, question, answers: [], };
        if (!user || user.login === false) {
            throw new Error("You should be logged in to post questions");
        }
        if (question === "") {
            throw new Error("Invalid question");
        }
        this._questions.push(currQuestion);
        return "Your question has been posted successfully";
    }

    postAnswer(username, questionId, answer) {
        const user = this._users.find(u => u.username === username);
        const question = this._questions.find(u => u.id === questionId);
        const currAnswer = { answer, username, questionId, };
        if (!user || user.login === false) {
            throw new Error("You should be logged in to post answers");
        }
        if (answer === "") {
            throw new Error("Invalid answer");
        }
        if (!question) {
            throw new Error("There is no such question");
        }
        question.answers.push(currAnswer);
        return "Your answer has been posted successfully";
    }

    showQuestions() {
        return this._questions
            .map(({ id, username, question, answers }) => `Question ${id} by ${username}: ${question}\n${answers
                .map(({ username, answer }) => `---${username}: ${answer}`)
                .join('\n')}`)
            .join('\n');
    }
}