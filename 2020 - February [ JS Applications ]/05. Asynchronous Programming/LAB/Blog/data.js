import { fetchData } from "./genericFetch.js";
export class Data {
    myFetch;
    rootUrl;
    urlTemplate;
    constructor(rootUrl, urlTemplate, withCache) {
        this.rootUrl = rootUrl;
        this.urlTemplate = urlTemplate.bind(this);
        this.myFetch = withCache(fetchData.bind(window, undefined, undefined), 10000);
    }
    getPosts() {
        return this.myFetch(this.urlTemplate("posts"));
    }
    getPost(id) {
        return this.myFetch(this.urlTemplate(`posts/${id}`));
    }
    getComments() {
        return this.myFetch(this.urlTemplate("comments"));
    }
}
