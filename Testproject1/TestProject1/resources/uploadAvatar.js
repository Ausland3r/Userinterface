function uploadAvatar(base64Image) {
    const vueInstance = document.querySelector('.avatar-and-interests')?.__vue__;
    if (vueInstance && typeof vueInstance.onAvatarComplete === 'function') {
        vueInstance.onAvatarComplete(base64Image);
    }
}

uploadAvatar(arguments[0]);
