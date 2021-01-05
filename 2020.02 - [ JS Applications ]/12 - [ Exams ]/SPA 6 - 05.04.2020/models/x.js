export default {
    createDocument(data) {
        return firebase.firestore().collection("articles").add(data);
    },
    getAll() {
        return firebase.firestore().collection("articles").get();
    },
    getDocument(id) {
        return firebase.firestore().collection("articles").doc(id).get();
    },
    deleteDocument(id) {
        return firebase.firestore().collection("articles").doc(id).delete();
    },
    updateDocument(id, data) {
        return firebase.firestore().collection("articles").doc(id).update(data);
    },
};