export function displayPosts(html, posts) {
    let fragment = document.createDocumentFragment();
    Object.keys(posts).forEach(x => {
        let option = document.createElement("option");
        option.value = x;
        option.innerHTML = posts[x].title;
        fragment.appendChild(option);
    });
    html.select().innerHTML = "";
    html.select().appendChild(fragment);
}

export function displayPost(html, comments, post) {
    displayComments(html, comments, post);
    Object.keys(post).forEach(x => {
        if (typeof html[x] === "function") {
            html[x]().innerHTML = post[x];
        }
    });
}

function displayComments(html, comments, post) {
    html.comments().innerHTML = "";
    Object
        .keys(comments)
        .filter(x => comments[x].postId === post.id)
        .map(x => comments[x])
        .map(x => {
            let li = document.createElement("li");
            li.innerHTML = x.text;
            return li;
        })
        .forEach(x => {
            html.comments().appendChild(x);
        });
}
