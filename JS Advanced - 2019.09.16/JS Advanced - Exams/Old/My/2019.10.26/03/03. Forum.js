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

        
        




    }

    showQuestions() {

    }

}

let forum = new Forum();

forum.register('Michael', '123', '123', 'michael@abv.bg');
forum.register('Stoyan', '123ab7', '123ab7', 'some@gmail@.com');
forum.login('Michael', '123');
forum.login('Stoyan', '123ab7');

forum.postQuestion('Michael', "Can I rent a snowboard from your shop?");
forum.postAnswer('Stoyan', 1, "Yes, I have rented one last year.");
forum.postQuestion('Stoyan', "How long are supposed to be the ski for my daughter?");
forum.postAnswer('Michael', 2, "How old is she?");
forum.postAnswer('Michael', 2, "Tell us how tall she is.");

console.log(forum.showQuestions());

// Question 1 by Michael: Can I rent a snowboard from your shop?
// ---Stoyan: Yes, I have rented one last year.
// Question 2 by Stoyan: How long are supposed to be the ski for my daughter?
// ---Michael: How old is she?
// ---Michael: Tell us how tall she is.
