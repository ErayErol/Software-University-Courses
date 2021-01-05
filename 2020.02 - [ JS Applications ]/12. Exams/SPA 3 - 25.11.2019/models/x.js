export default {
    createDocument(data) {
        return firebase.firestore().collection("recipes").add(data);
    },
    getAll() {
        return firebase.firestore().collection("recipes").get();
    },
    getDocument(id) {
        return firebase.firestore().collection("recipes").doc(id).get();
    },
    deleteDocument(id) {
        return firebase.firestore().collection("recipes").doc(id).delete();
    },
    updateDocument(id, data) {
        return firebase.firestore().collection("recipes").doc(id).update(data);
    },
};