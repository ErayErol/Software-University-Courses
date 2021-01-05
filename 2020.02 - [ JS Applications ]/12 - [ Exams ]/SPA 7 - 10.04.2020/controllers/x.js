import docModifier from "../utils/doc-modifier.js";
import extend from "../utils/context.js";
import models from "../models/index.js";

export default {
    get: {
        create(context) {
            extend(context).then(function () {
                this.partial("../views/home/home.hbs");
            });
        },
        edit(context) {
            const { xId } = context.params;
            context.xId = xId;
            models.x.getDocument(xId)
                .then((response) => {
                    let x = docModifier(response);
                    const { uid } = x;
                    if (uid === localStorage.getItem("userId")) {
                        const { title, category, content } = x;
                        context.title = title;
                        context.category = category;
                        context.content = content;

                        extend(context).then(function () {
                            this.partial("../views/x/edit.hbs");
                        });
                    } else {
                        context.redirect("#/home");
                        toastr.warning("You only can edit posts that you created!");
                    }
                }).catch((e) => console.error(e));
        },
        details(context) {
            const { xId } = context.params;
            context.xId = xId;
            models.x.getDocument(xId)
                .then((response) => {
                    const x = docModifier(response);
                    context.posts = x;

                    Object.keys(x).forEach((key) => {
                        context[key] = x[key];
                    });

                    extend(context).then(function () {
                        this.partial("../views/x/details.hbs");
                    });
                }).catch((e) => console.error(e));
        },
    },
    post: {
        create(context) {
            const data = {
                ...context.params,
                uid: localStorage.getItem("userId"),
            };

            models.x.createDocument(data)
                .then((response) => {
                    toastr.success("Added post!");
                    context.redirect("#/home");
                }).catch((e) => console.error(e));
        },
        edit(context) {
            let xId = localStorage.getItem("xId");
            models.x.getDocument(xId)
                .then((response) => {
                    let x = docModifier(response);
                    const { title, category, content } = context.params;
                    x.title = title;
                    x.category = category;
                    x.content = content;
                    return models.x.updateDocument(xId, x);
                }).then((response2) => {
                    toastr.success("Edited post!");
                    context.redirect(`#/home`);
                })
                .catch((e) => console.error(e));
        },
    },
    del: {
        deleteX(context) {
            const { xId } = context.params;
            models.x.getDocument(xId)
                .then((response) => {
                    let x = docModifier(response);
                    let { uid } = x;
                    if (uid === localStorage.getItem("userId")) {
                        models.x.deleteDocument(xId)
                            .then((response) => {
                                toastr.success('Post is deleted!');
                                context.redirect("#/home");
                            }).catch((e) => console.error(e));
                    } else {
                        context.redirect("#/home");
                        toastr.warning("You only can delete posts that you created!");
                    }
                }).catch((e) => console.error(e));
        },
    },
};