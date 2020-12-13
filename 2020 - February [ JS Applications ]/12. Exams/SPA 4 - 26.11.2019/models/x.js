export default {
    createDocument(data) {
        return firebase.firestore().collection("events").add(data);
    },
    getAll() {
        return firebase.firestore().collection("events").get();
    },
    getDocument(id) {
        return firebase.firestore().collection("events").doc(id).get();
    },
    deleteDocument(id) {
        return firebase.firestore().collection("events").doc(id).delete();
    },
    updateDocument(id, data) {
        return firebase.firestore().collection("events").doc(id).update(data);
    },
};