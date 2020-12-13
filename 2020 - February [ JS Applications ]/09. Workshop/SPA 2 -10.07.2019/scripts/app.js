import controllers from "../controllers/index.js";

const app = Sammy("#root", function () {

    this.use("Handlebars", "hbs");

    // Home
    this.get("#/home", controllers.home.get.home);

    // Users
    this.get("#/user/login", controllers.user.get.login);
    this.post("#/user/login", controllers.user.post.login);
    
    this.get("#/user/register", controllers.user.get.register);
    this.post("#/user/register", controllers.user.post.register);

    this.get("#/user/logout", controllers.user.get.logout);

    // Collection
    this.get("#/x/create", controllers.x.get.create);
    this.post("#/x/create", controllers.x.post.create);

    this.get("#/x/dashboard", controllers.x.get.dashboard);
    this.get("#/x/dashboard/details/:xId", controllers.x.get.details);
    
    this.get("#/x/update/:xId", controllers.x.put.updateX);
    this.get("#/x/delete/:xId", controllers.x.del.deleteX);
});

(() => {
    app.run("#/home");
})();