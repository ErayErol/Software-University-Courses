import docModifier from "../utils/doc-modifier.js";
import extend from "../utils/context.js";
import models from "../models/index.js";

export default {
    get: {
        create(context) {
            extend(context).then(function () {
                this.partial("../views/x/create.hbs");
            });
        },
        details(context) {
            const { xId } = context.params;
            context.xId = xId;
            models.x.getDocument(xId)
                .then((response) => {
                    const x = docModifier(response);
                    context.y = x;
                    context.canZ = x.uid === localStorage.getItem("userId");

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
                likes: 0,
                organizer: localStorage.getItem("userEmail"),
                comments: [],
            };

            models.x.createDocument(data)
                .then((response) => {
                    context.redirect("#/home");
                }).catch((e) => console.error(e));
        },
    },
    del: {
        deleteX(context) {
            const { xId } = context.params;
            models.x.deleteDocument(xId)
                .then((response) => {
                    context.redirect("#/home");
                }).catch((e) => console.error(e));
        },
    },
    put: {
        likes(context) {
            const { xId } = context.params;
            models.x.getDocument(xId)
                .then((response) => {
                    let x = docModifier(response);
                    x.likes++;
                    return models.x.updateDocument(xId, x);
                }).then((response2) => {
                    context.redirect(`#/x/details/${xId}`); 
                }).catch((e) => console.error(e));
        },
        comments(context){
            const { xId } = context.params;
            models.x.getDocument(xId)
                .then((response) => {
                    let x = docModifier(response);
                    x.comments.push(`${localStorage.getItem("userEmail")} : ${context.params.newComment}`);
                    return models.x.updateDocument(xId, x);
                }).then((response2) => {
                    context.redirect(`#/x/details/${xId}`);
                }).catch((e) => console.error(e));
        }
    },
};