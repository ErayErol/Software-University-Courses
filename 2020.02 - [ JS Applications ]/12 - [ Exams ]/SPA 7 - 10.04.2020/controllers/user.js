import models from "../models/index.js";
import extend from "../utils/context.js";
import checkSymbols from "../utils/validEmailSymbolsChecker.js";

export default {
    get: {
        async login(context) {
            await extend(context).partial("../views/user/login.hbs");
            checkSymbols();
        },
        async register(context) {
            await extend(context).partial("../views/user/register.hbs");
            checkSymbols();
        },
        logout(context) {
            models.user.logout();
            toastr.info("Good bye!");
            context.redirect("#/home");
        }
    },
    post: {
        login(context) {
            const { email, password } = context.params;

            const correctData = async () => {
                const response = await models.user.login(email, password);
                context.user = response;
                context.email = response.email;
                context.isLoggedIn = true;

                toastr.success(`Hi, ${email}! You are in!`);
                context.redirect("#/home");
            };

            correctData()
                .then()
                .catch(() => toastr.error('Invalid username or password!'));
        },
        register(context) {
            const { email, password, repeatPassword } = context.params;

            const correctData = async () => {
                if (password === repeatPassword) {
                    await models.user.register(email, password);
                    context.redirect("#/user/login");
                    toastr.success('Successful registration!');
                } else {
                    toastr.error('Passwords must be equal!');
                }
            };

            correctData()
                .then()
                .catch((e) => {
                    toastr.error(e.message);
                    context.redirect("#/user/register");
                });
        }
    }
};