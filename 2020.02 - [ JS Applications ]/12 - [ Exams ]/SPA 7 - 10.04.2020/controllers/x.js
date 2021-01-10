import docModifier from "../utils/doc-modifier.js";
import extend from "../utils/context.js";
import models from "../models/index.js";

export default {
    get: {
        edit(context) {
            (async () => {
                const { xId } = context.params;
                context.xId = xId;
                const response = await models.x.getDocument(context.xId);
                const x = docModifier(response);

                if (x.uid === localStorage.getItem("userId")) {
                    context.title = x.title;
                    context.category = x.category;
                    context.content = x.content;

                    const sammy = extend(context);
                    sammy.partial("../views/x/edit.hbs");
                } else {
                    context.redirect("#/home");
                    toastr.warning("You only can edit posts that you created!");
                }
            })();
        },
        details(context) {
            (async () => {
                context.xId = context.params.xId;
                const response = await models.x.getDocument(context.xId);
                const x = docModifier(response);
                context.posts = x;

                Object.keys(x).forEach((key) => {
                    context[key] = x[key];
                });

                const sammy = extend(context);
                sammy.partial("../views/x/details.hbs");
            })();
        },
    },
    post: {
        create(context) {
            (async () => {
                const data = {
                    ...context.params,
                    uid: localStorage.getItem("userId"),
                };

                await models.x.createDocument(data);
                toastr.success("Added post!");
                context.redirect("#/home");
            })();
        },
        edit(context) {
            (async () => {
                const xId = localStorage.getItem("xId");
                const response = await models.x.getDocument(xId);
                const x = docModifier(response);
                x.title = context.params.title;
                x.category = context.params.category;
                x.content = context.params.content;
                toastr.success("Edited post!");
                context.redirect(`#/home`);
                return await models.x.updateDocument(xId, x);
            })();
        },
    },
    del: {
        deleteX(context) {
            (async () => {
                const { xId } = context.params;
                const response = await models.x.getDocument(xId);
                const x = docModifier(response);

                if (x.uid === localStorage.getItem("userId")) {
                    await models.x.deleteDocument(xId);
                    toastr.success('Post is deleted!');
                    context.redirect("#/home");
                } else {
                    toastr.warning("You only can delete posts that you created!");
                }
            })();
        },
    },
};