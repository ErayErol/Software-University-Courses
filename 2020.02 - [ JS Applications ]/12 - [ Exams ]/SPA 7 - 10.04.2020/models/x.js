export default {
    createDocument(data) {
        return firebase.firestore().collection("posts").add(data);
    },
    getAll() {
        return firebase.firestore().collection("posts").get();
    },
    getDocument(id) {
        return firebase.firestore().collection("posts").doc(id).get();
    },
    deleteDocument(id) {
        return firebase.firestore().collection("posts").doc(id).delete();
    },
    updateDocument(id, data) {
        return firebase.firestore().collection("posts").doc(id).update(data);
    },
};