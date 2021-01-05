import docModifier from "../utils/doc-modifier.js";
import extend from "../utils/context.js";
import models from "../models/index.js";

export default {
    get: {
        dashboard(context) {
            models.x.getAll()
                .then((response) => {
                    const y = response.docs.map(docModifier);
                    if (y.length > 0) {
                        context.y = y;
                    }
                }).then((response2) => {
                    extend(context).then(function () {
                        this.partial("../views/x/dashboard.hbs");
                    });
                }).catch((e) => {
                    extend(context).then(function () {
                        this.partial("../views/x/dashboard.hbs");
                    });
                });
        },
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
                collectedFunds: 0,
                donors: [],
            };

            models.x.createDocument(data)
                .then((response) => {
                    context.redirect("#/home");
                }).catch((e) => console.error(e));
        },
    },
    del: {
        deleteX(context) {
            let xId = localStorage.getItem("xId");
            models.x.deleteDocument(xId)
                .then((response) => {
                    context.redirect("#/home");
                }).catch((e) => console.error(e));
        },
    },
    put: {
        updateX(context) {
            let xId = localStorage.getItem("xId");
            models.x.getDocument(xId)
                .then((response) => {
                    let x = docModifier(response);
                    let donor = localStorage.getItem("userEmail");
                    x.donors.push(donor);
                    context.donors = x.donors;
                    x.collectedFunds = Number(x.collectedFunds) + Number(context.params.collectedFunds);;
                    context.collectedFunds = x.collectedFunds;
                    return models.x.updateDocument(xId, x);
                }).then((response2) => {
                    context.redirect(`#/x/dashboard/details/${xId}`);
                }).catch((e) => console.error(e));
        }
    },
};