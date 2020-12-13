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
                    toastr.info("Good bye!");
                    context.redirect("#/home");
                }).catch((e) => console.error(e));
        }
    },
    post: {
        login(context) {
            const { email, password } = context.params;
            models.user.login(email, password)
                .then((response) => {
                    context.user = response;
                    context.email = response.email;
                    context.isLoggedIn = true;

                    toastr.success(`Hi, ${email}! You are in!`);
                    context.redirect("#/home");
                }).catch((e) => toastr.error('Invalid username or password!'));
        },
        register(context) {
            const { email, password, repeatPassword } = context.params;

            if (password === repeatPassword) {
                context.redirect("#/user/login");
                models.user.register(email, password)
                    .then((response) => {
                        toastr.success('Successful registration!');
                    }).catch((e) => {
                        toastr.error(e.message);
                        context.redirect("#/user/register");
                    });
            } else {
                toastr.error('Passwords must be equal!');
            }
        }
    }
};