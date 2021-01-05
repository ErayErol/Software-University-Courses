function solve() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);

            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = [];
        }

        addComment(comment) {
            this.comments.push(comment);
        }

        toString() {
            if (this.comments.length > 0) {
                return `${super.toString()}\nRating: ${this.likes - this.dislikes}\nComments:\n * ${this.comments.join('\n * ')}`;
            }

            return `${super.toString()}\nRating: ${this.likes - this.dislikes}`;
        }
    }

    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content);

            this.views = views;
        }

        view() {
            this.views++;
            return this;
        }

        toString() {
            return `${super.toString()}\nViews: ${this.views}`;
        }
    }

    class Instagram extends SocialMediaPost {
        constructor(title, content, likes, dislikes, follows) {
            super(title, content, likes, dislikes);

            this.follows = follows;
        }

        toString() {
            return `${Post.prototype.toString.call(this)}\nFollows: ${this.follows}`;
            // Instagram parent -> SocialMediaPost
            // SocialMediaPost parent -> Post
            // Post.prototype.(write the method that want to call).call(this);
        }
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost,
        Instagram
    };
}

let create = solve();

let post = new create.Post('Who is Eray Erol?', 'The boy who know why to live!');
console.log(post.toString());

let scm = new create.SocialMediaPost('From zero to hero!', 'The story of Eray Erol.', 9750500, 86);
scm.addComment('Good man.');
scm.addComment('Wow!');
scm.addComment('Who the fu*k is he? And why I\'m reading this post?');
scm.addComment('Great story.');
console.log(scm.toString());

let bp = new create.BlogPost('What is Blog Post?', 'Read to know.', 5);
bp.view().view().view();

let instagram = new create.Instagram('Workout', 'Your dream body', 330, 2, 11750);
console.log(instagram.toString());