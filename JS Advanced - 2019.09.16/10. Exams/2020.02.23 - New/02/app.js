class Article {
    _commentId = 1;
    _comments = [];
    _likes = [];
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
    }

    get likes() {
        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`;
        }
        if (this._likes.length === 1) {
            return `${this._likes[0]} likes this article!`;
        }

        return `${this._likes[0]} and ${this._likes.length - 1} others like this article!`;
    }

    like(username) {
        if (this._likes.includes(username)) {
            throw new Error("You can't like the same article twice!");
        }
        if (this.creator === username) {
            throw new Error("You can't like your own articles!");
        }
        this._likes.push(username);
        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        if (!this._likes.includes(username)) {
            throw new Error(`You can't dislike this article!`);
        }
        const index = this._likes.findIndex(u => u === username);
        this._likes.splice(index, 1);
        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        let comment = this._comments.find(c => c.id == id);

        if (!comment || !id) {
            let newComment = {
                id: this._commentId ++,
                username,
                content,
                replies: [],
            };

            this._comments.push(newComment);
            return `${username} commented on ${this.title}`;
        }

        let newReply = { id: comment.replies.length + 1, username, content };
        comment.replies.push(newReply);
        return "You replied successfully";
    }

    toString(sortingType) {
        let x = [];
        x.push(`Title: ${this.title}`);
        x.push(`Creator: ${this.creator}`);
        x.push(`Likes: ${this._likes.length}`);
        x.push("Comments:");

        if (sortingType === 'username') {
            this.compareFunc(compareUser, x);
        } else if (sortingType === 'desc') {
            this.compareFunc(compareDesc, x);
        } else if (sortingType === 'asc') {
            this.compareFunc(compareAsc, x);
        }

        return x.join("\n");

        function compareUser(a, b) {
            if (a.username < b.username) {
                return -1;
            }
            if (a.username > b.username) {
                return 1;
            }
            return 0;
        }

        function compareAsc(a, b) {
            if (a.id < b.id) {
                return -1;
            }
            if (a.id > b.id) {
                return 1;
            }
            return 0;
        }

        function compareDesc(a, b) {
            if (a.id > b.id) {
                return -1;
            }
            if (a.id < b.id) {
                return 1;
            }
            return 0;
        }
    }

    compareFunc(compareName, x) {
        this._comments.sort(compareName);
        this._comments.forEach((r) => {
            let currCom = this._comments.find(c => c.id === r.id);
            x.push(`-- ${currCom.id}. ${currCom.username}: ${currCom.content}`);
            if (r.replies.length > 0) {
                r.replies.sort(compareName);
                r.replies.forEach(({ username, content, id }) => {
                    x.push(`--- ${currCom.id}.${id}. ${username}: ${content}`);
                });
            }
        });
    }
}

let art = new Article("My Article", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));