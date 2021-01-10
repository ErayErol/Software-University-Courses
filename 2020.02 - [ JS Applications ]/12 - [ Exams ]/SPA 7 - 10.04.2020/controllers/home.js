import docModifier from "../utils/doc-modifier.js";
import extend from "../utils/context.js";
import models from "../models/index.js";

export default {
    get: {
        home(context) {
            const getBlogs = async () => {
                const response = await models.x.getAll();
                const y = response.docs.map(docModifier);
                if (y.length > 0) {
                    context.posts = y;
                }
            };

            function output() {
                const sammy = extend(context);
                sammy.partial("../views/home/home.hbs");
            }

            getBlogs()
                .then(output)
                .catch(output);
        }
    },
};