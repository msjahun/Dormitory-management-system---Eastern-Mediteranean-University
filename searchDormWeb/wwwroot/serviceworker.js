console.log("Service Worker Loaded...");

//self.addEventListener("push", e => {
//    const data = e.data.json();
//    console.log("Push Recieved...");
//    self.registration.showNotification(data.title, {
//        body: "Notified by Traversy Media!",
//        icon: "http://image.ibb.co/frYOFd/tmlogo.png"
//    });
//});

self.addEventListener('push', function (event) {
    if (event.data) {
        console.log('This push event has data: ', event.data.text());
    } else {
        console.log('This push event has no data.');
    }
});