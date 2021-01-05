import { withCache } from "./withCache.js";
import { Data } from "./data.js";
import { displayPosts, displayPost } from "./views.js";

const data = new Data(
    "https://blog-apps-c12bf.firebaseio.com/",
    function (x) { return `${this.rootUrl}${x}/.json` },
    withCache
);

const actions = {
    btnLoadPosts: async () => {
        let posts = await data.getPosts();
        displayPosts(html, posts);
    },
    btnViewPost: async () => {
        const post = await data.getPost(html.select().value);
        const comments = await data.getComments();
        displayPost(html, comments, post);
    },
}

function handleEvent(e) {
    if (typeof actions[e.target.id] === "function") {
        actions[e.target.id]();
    }
}

const html = {
    select: () => document.getElementById("posts"),
    body: () => document.getElementById("post-body"),
    title: () => document.getElementById("post-title"),
    comments: () => document.getElementById("post-comments")
}

function attachEvents() {
    document.addEventListener("click", handleEvent);
}

attachEvents();