class Forum {
    constructor() {
        this._users = [];
        this._questions = [];
        this._id = 1;
    }

    register(username, password, repeatPassword, email) {
        if (username === '' || password === '' || repeatPassword === '' || email === '') {
            throw new Error('Input can not be empty');
        }

        if (password !== repeatPassword) {
            throw new Error('Passwords do not match');
        }

        let user = this._users.find(u => u.username === username);

        if (!user) {
            let newUser = {
                username,
                password,
                email,
            };

            this._users.push(newUser);

            return `${username} with ${email} was registered successfully!`;
        }

        if (user.username === username && user.email === email) {
            throw new Error('This user already exists!');
        }
    }

    login(username, password) {
        let user = this._users.find(u => u.username === username);

        if (!user) {
            throw new Error('There is no such user');
        }

        if (user.username === username && user.password === password) {
            user.log = true;
            return `Hello! You have logged in successfully`;
        }
    }

    logout(username, password) {
        let user = this._users.find(u => u.username === username);

        if (!user) {
            throw new Error('There is no such user');
        }

        if (user.username === username && user.password === password) {
            user.log = false;
            return `You have logged out successfully`;
        }
    }

    postQuestion(username, question) {
        let user = this._users.find(u => u.username === username);

        if (!user || user.log == false) {
            throw new Error('You should be logged in to post questions');
        }

        if (question === '') {
            throw new Error('Invalid question');
        }
        
        let id = this._id++;
        let qa = {
            usernameQestion: username,
            question: question,
            id,
            answer: []
        };

        this._questions.push(qa);

        return `Your question has been posted successfully`;
    }

    postAnswer(username, questionId, answer) {
        let user = this._users.find(u => u.username === username);

        if (!user || user.log == false) {
            throw new Error('You should be logged in to post answers');
        }

        if (answer === '') {
            throw new Error('Invalid answer');
        }

        let find = this._questions.find(x => x.id === questionId);

        if (!find) {
            throw new Error('There is no such question');
        }

        let findIndex = this._questions.findIndex(x => x.id === questionId);


        this._questions[findIndex].answer.push(answer);
        this._questions[findIndex].usernameAns = username;

        return "Your answer has been posted successfully";
    }

    showQuestions() {
        let result = [];
        for (const question of this._questions) {
            result.push(`Question ${question.id} by ${question.usernameQestion}: ${question.question}`);

            for (let i = 0; i < question.answer.length; i++) {
                const element = question.answer[i];
                result.push(`---${question.usernameAns}: ${element}`);
            }
        }

        return result.join('\n');

    }
}

let forum = new Forum();

forum.register('Jonny', '12345', '12345', 'jonny@abv.bg');
forum.register('Peter', '123ab7', '123ab7', 'peter@gmail@.com');
forum.login('Jonny', '12345');
forum.login('Peter', '123ab7');

forum.postQuestion('Jonny', "Do I need glasses for skiing?");
forum.postAnswer('Peter',1, "Yes, I have rented one last year.");
forum.postAnswer('Jonny',1, "What was your budget");
forum.postAnswer('Peter',1, "$50");
forum.postAnswer('Jonny',1, "Thank you :)");

console.log(forum.showQuestions());
