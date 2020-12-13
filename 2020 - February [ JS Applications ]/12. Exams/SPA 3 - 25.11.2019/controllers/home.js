import docModifier from "../utils/doc-modifier.js";
import extend from "../utils/context.js";
import models from "../models/index.js";

export default {
    get: {
        home(context) {
            models.x.getAll()
                .then((response) => {
                    const y = response.docs.map(docModifier);
                    if (y.length > 0) {
                        context.y = y;
                    }
                }).then((response2) => {
                    extend(context).then(function () {
                        this.partial("../views/home/home.hbs");
                    });
                }).catch((e) => {
                    extend(context).then(function () {
                        this.partial("../views/home/home.hbs");
                    });
                });
        }
    },
};