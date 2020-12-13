function attachEvents() {
    const postsSelect = document.getElementById('posts');
    const btnLoadPosts = document.getElementById('btnLoadPosts');
    const btnViewPost = document.getElementById('btnViewPost');
    const postTitle = document.getElementById('post-title');
    const postBody = document.getElementById('post-body');
    const postComments = document.getElementById('post-comments');

    btnLoadPosts.addEventListener('click', loadPosts);
    btnViewPost.addEventListener('click', viewPost);

    function loadPosts() {
        fetch('https://blog-apps-c12bf.firebaseio.com/posts.json')
            .then(cleaner())
            .then(res => renderResponse(res))
            .then(data => addingPosts(data))
            .catch(() => renderErrorMessage());
    }

    function addingPosts(data) {
        Object.entries(data).forEach((post) => {
            const option = document.createElement('option');
            option.value = post[0];
            option.textContent = post[1].title;
            postsSelect.appendChild(option);
        });
    }

    function viewPost() {
        fetch(`https://blog-apps-c12bf.firebaseio.com/posts/${postsSelect.value}.json`)
            .then(cleaner())
            .then(res => renderResponse(res))
            .then(data => displayPost(data))
            .catch(() => renderErrorMessage());
    }

    function displayPost(post) {
        const p = document.createElement('p');
        postTitle.textContent = post.title;
        p.textContent = post.body;
        postBody.appendChild(p);
        viewComments(post.id);
    }

    function viewComments(postId) {
        fetch(`https://blog-apps-c12bf.firebaseio.com/comments/.json`)
            .then(res => renderResponse(res))
            .then(data => addingComments(data, postId))
            .catch(() => renderErrorMessage());
    }

    function addingComments(data, postId) {
        for (const key in data) {
            if (data[key].postId === postId) {
                const { id, text } = data[key];
                const li = document.createElement('li');
                li.textContent = text;
                li.id = id;
                postComments.appendChild(li);
            }
        }
    }

    function cleaner() {
        postsSelect.innerHTML = '';
        postTitle.innerHTML = 'Post Details';
        postBody.innerHTML = '';
        postComments.innerHTML = '';
    }

    function renderErrorMessage() {
        document.body.innerHTML = `<h1>Incorrect URL</h1>`;
    }

    function renderResponse(res) {
        return res.json();
    }
}

attachEvents();