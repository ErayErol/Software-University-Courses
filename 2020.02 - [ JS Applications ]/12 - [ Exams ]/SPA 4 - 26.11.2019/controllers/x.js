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
        edit(context) {
            const { xId } = context.params;
            context.xId = xId;
            models.x.getDocument(xId)
                .then((response) => {
                    let x = docModifier(response);
                    const { name, dateTime, imageURL, description } = x;
                    context.name = name;
                    context.dateTime = dateTime;
                    context.description = description;
                    context.imageURL = imageURL;

                    extend(context).then(function () {
                        this.partial("../views/x/edit.hbs");
                    });
                }).catch((e) => console.error(e));
        }
    },
    post: {
        create(context) {
            const data = {
                ...context.params,
                uid: localStorage.getItem("userId"),
                organizer: localStorage.getItem("userEmail"),
                peopleInterestedIn: 0,
            };

            models.x.createDocument(data)
                .then((response) => {
                    context.redirect("#/home");
                }).catch((e) => console.error(e));
        },
        edit(context) {
            let xId = localStorage.getItem("xId");
            models.x.getDocument(xId)
                .then((response) => {
                    let x = docModifier(response);
                    const { name, dateTime, imageURL, description } = context.params;
                    x.name = name;
                    x.dateTime = dateTime;
                    x.description = description;
                    x.imageURL = imageURL;
                    return models.x.updateDocument(xId, x);
                }).then((response2) => {
                    context.redirect(`#/home`);
                })
                .catch((e) => console.error(e));
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
        updateX(context) {
            const { xId } = context.params;
            models.x.getDocument(xId)
                .then((response) => {
                    let x = docModifier(response);
                    x.peopleInterestedIn++;
                    return models.x.updateDocument(xId, x);
                }).then((response2) => {
                    context.redirect(`#/x/details/${xId}`);
                }).catch((e) => console.error(e));
        }
    },
};