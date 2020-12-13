export default {
    createDocument(data) {
        return firebase.firestore().collection("ideas").add(data);
    },
    getAll() {
        return firebase.firestore().collection("ideas").get();
    },
    getDocument(id) {
        return firebase.firestore().collection("ideas").doc(id).get();
    },
    deleteDocument(id) {
        return firebase.firestore().collection("ideas").doc(id).delete();
    },
    updateDocument(id, data) {
        return firebase.firestore().collection("ideas").doc(id).update(data);
    },
};