class Article {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this.idC = 1;
        this._likes = [];
        this.likeNames = [];
    }

    get likes() {
        if (this.likeNames.length === 0) {
            return `${this.title} has 0 likes`;
        }
        if (this.likeNames.length === 1) {
            return `${this.likeNames[0]} likes this article!`;
        }

        return `${this.likeNames[0]} and ${this.likeNames.length - 1} others like this article!`;
    }

    like(username) {
        if (this.likeNames.includes(username)) {
            throw new Error("You can't like the same article twice!");
        }
        if (this.creator === username) {
            throw new Error("You can't like your own articles!");
        }
        this.likeNames.push(username);
        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        if (this.likeNames[0] !== username) {
            throw new Error("You can't dislike this article!");
        }

        this.likeNames.shift();
        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        let comment = this._comments.find(c => c.id == id);

        if (!comment || !id) {
            let newComment = {
                id: this.idC++,
                username,
                content,
                reply: [],
            };

            this._comments.push(newComment);
            return `${username} commented on ${this.title}`;
        }

        let newReply = { id, username, content };
        newReply.id = comment.reply.length + 1;
        comment.reply.push(newReply);
        return "You replied successfully";
    }

    toString(sortingType) {
        let x = [];
        x.push(`Title: ${this.title}`);
        x.push(`Creator: ${this.creator}`);
        x.push(`Likes: ${this.likeNames.length}`);
        x.push("Comments:");

        if (sortingType === 'username') {
            this._comments.sort(compareUser);
            this._comments.forEach((r) => {
                let currCom = this._comments.find(c => c.id === r.id);
                x.push(`-- ${currCom.id}. ${currCom.username}: ${currCom.content}`);
                if (r.reply.length > 0) {
                    r.reply.sort(compareUser);
                    r.reply.forEach(({ username, content, id }) => {
                        x.push(`--- ${currCom.id}.${id}. ${username}: ${content}`)
                    });
                }
            });



        } else if (sortingType === 'desc') {
            this._comments.sort(compareDesc);
            this._comments.forEach((r) => {
                let currCom = this._comments.find(c => c.id === r.id);
                x.push(`-- ${currCom.id}. ${currCom.username}: ${currCom.content}`);
                if (r.reply.length > 0) {
                    r.reply.sort(compareDesc);
                    r.reply.forEach(({ username, content, id }) => {
                        x.push(`--- ${currCom.id}.${id}. ${username}: ${content}`)
                    });
                }
            });



        } else if (sortingType === 'asc') {
            this._comments.sort(compareAsc);
            this._comments.forEach((r) => {
                let currCom = this._comments.find(c => c.id === r.id);
                x.push(`-- ${currCom.id}. ${currCom.username}: ${currCom.content}`);
                if (r.reply.length > 0) {
                    r.reply.sort(compareAsc);
                    r.reply.forEach(({ username, content, id }) => {
                        x.push(`--- ${currCom.id}.${id}. ${username}: ${content}`)
                    });
                }
            });
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

// John likes this article!
// My Article has 0 likes
// Ammy commented on My Article
// You replied successfully

// Title: My Article
// Creator: Anny
// Likes: 0
// Comments:
// -- 2. Ammy: New Content
// -- 3. Jessy: Nice :)
// -- 1. Sammy: Some Content
// --- 1.2. SAmmy: Reply@
// --- 1.1. Zane: Reply

// Title: My Article
// Creator: Anny
// Likes: 1
// Comments:
// -- 3. Jessy: Nice :)
// -- 2. Ammy: New Content
// -- 1. Sammy: Some Content
// --- 1.2. SAmmy: Reply@
// --- 1.1. Zane: Reply