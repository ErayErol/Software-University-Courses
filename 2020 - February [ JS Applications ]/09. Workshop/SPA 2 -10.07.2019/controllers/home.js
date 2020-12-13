import extend from "../utils/context.js";

export default {
    get: {
        home(context) {
            extend(context).then(function () {
                this.partial("../views/home/home.hbs");
            });
        }
    },
};