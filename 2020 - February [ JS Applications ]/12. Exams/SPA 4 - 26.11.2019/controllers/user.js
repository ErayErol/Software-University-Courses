import docModifier from "../utils/doc-modifier.js";
import models from "../models/index.js";
import extend from "../utils/context.js";

export default {
    get: {
        login(context) {
            extend(context).then(function () {
                this.partial("../views/user/login.hbs");
            });
        },
        register(context) {
            extend(context).then(function () {
                this.partial("../views/user/register.hbs");
            });
        },
        logout(context) {
            models.user.logout()
                .then((response) => {
                    context.redirect("#/home");
                }).catch((e) => console.error(e));
        },
        profile(context) {
            context.count = 0;
            models.x.getAll()
                .then((response) => {
                    const events = response.docs.map(docModifier);
                    events.forEach((event) => {
                        if (event.organizer === localStorage.getItem("userEmail")) {
                            context.haveEvents = true;
                            context.count++;
                            if (context.hasOwnProperty("events") == false) {
                                context.events = [];
                            }
                            context.events.push(event.name);
                        }
                    });
                }).then((response2) => {
                    extend(context).then(function () {
                        this.partial("../views/user/profile.hbs");
                    });
                }).catch((e) => {
                    extend(context).then(function () {
                        this.partial("../views/user/profile.hbs");
                    });
                });
        },
    },
    post: {
        login(context) {
            const { username, password } = context.params;
            models.user.login(username, password)
                .then((response) => {
                    context.user = response;
                    context.username = response.username;
                    context.isLoggedIn = true;
                    context.redirect("#/home");
                }).catch((e) => console.error(e));
        },
        register(context) {
            const { username, password, rePassword } = context.params; // check names

            if (password === rePassword) {
                models.user.register(username, password)
                    .then((response) => {
                        context.redirect("#/home");
                    }).catch((e) => console.error(e));
            }
        },
    }
};