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
                    const { meal, ingredients, prepMethod, description, foodImageURL, category } = x;
                    context.meal = meal;
                    context.ingredients = ingredients;
                    context.prepMethod = prepMethod;
                    context.description = description;
                    context.foodImageURL = foodImageURL;
                    context.category = category;

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
                likesCounter: 0,
                categoryImageURL: "",
            };

            data.ingredients = data.ingredients.split(", ");

            if (data.category === "Vegetables and legumes/beans") {
                data.categoryImageURL = "https://cdn.pixabay.com/photo/2017/10/09/19/29/eat-2834549__340.jpg";
            } else if (data.category === "Fruits") {
                data.categoryImageURL = "https://cdn.pixabay.com/photo/2017/06/02/18/24/fruit-2367029__340.jpg";
            } else if (data.category === "Grain Food") {
                data.categoryImageURL = "https://cdn.pixabay.com/photo/2014/12/11/02/55/corn-syrup-563796__340.jpg";
            } else if (data.category === "Milk, cheese, eggs and alternatives") {
                data.categoryImageURL = "https://image.shutterstock.com/image-photo/assorted-dairy-products-milk-yogurt-260nw-530162824.jpg";
            } else if (data.category === "Lean meats and poultry, fish and alternatives") {
                data.categoryImageURL = "https://image.shutterstock.com/image-photo/roasted-dorado-fish-brussels-sprouts-260nw-435521527.jpg";
            }

            models.x.createDocument(data)
                .then((response) => {
                    localStorage.setItem("xId", response.id);
                    context.redirect("#/home");
                }).catch((e) => console.error(e));
        },
        edit(context) {
            let xId = localStorage.getItem("xId");
            models.x.getDocument(xId)
                .then((response) => {
                    const { meal, ingredients, prepMethod, description, foodImageURL, category } = context.params;

                    let x = docModifier(response);
                    x.meal = meal;
                    x.ingredients = ingredients.split(", ");
                    x.prepMethod = prepMethod;
                    x.description = description;
                    x.foodImageURL = foodImageURL;

                    if (category === "Vegetables and legumes/beans") {
                        x.categoryImageURL = "https://cdn.pixabay.com/photo/2017/10/09/19/29/eat-2834549__340.jpg";
                    } else if (category === "Fruits") {
                        x.categoryImageURL = "https://cdn.pixabay.com/photo/2017/06/02/18/24/fruit-2367029__340.jpg";
                    } else if (category === "Grain Food") {
                        x.categoryImageURL = "https://cdn.pixabay.com/photo/2014/12/11/02/55/corn-syrup-563796__340.jpg";
                    } else if (category === "Milk, cheese, eggs and alternatives") {
                        x.categoryImageURL = "https://image.shutterstock.com/image-photo/assorted-dairy-products-milk-yogurt-260nw-530162824.jpg";
                    } else if (category === "Lean meats and poultry, fish and alternatives") {
                        x.categoryImageURL = "https://image.shutterstock.com/image-photo/roasted-dorado-fish-brussels-sprouts-260nw-435521527.jpg";
                    }

                    return models.x.updateDocument(xId, x);
                }).then((response2) => {
                    context.redirect(`#/x/details/${xId}`);
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
                    x.likesCounter++;
                    return models.x.updateDocument(xId, x);
                }).then((response2) => {
                    context.redirect(`#/x/details/${xId}`);
                }).catch((e) => console.error(e));
        }
    },
};