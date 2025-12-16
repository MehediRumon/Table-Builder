window.initializePasteHandler = (dotNetHelper) => {
    const pasteArea = document.getElementById('pasteArea');
    
    if (pasteArea) {
        pasteArea.addEventListener('paste', async (e) => {
            e.preventDefault();
            
            const items = e.clipboardData?.items;
            if (!items) return;
            
            for (let i = 0; i < items.length; i++) {
                if (items[i].type.indexOf('image') !== -1) {
                    const blob = items[i].getAsFile();
                    const reader = new FileReader();
                    
                    reader.onload = async (event) => {
                        const dataUrl = event.target.result;
                        await dotNetHelper.invokeMethodAsync('HandlePastedImage', dataUrl);
                    };
                    
                    reader.readAsDataURL(blob);
                    break;
                }
            }
        });
    }
};

window.focusElement = (elementId) => {
    const element = document.getElementById(elementId);
    if (element) {
        element.focus();
    }
};

window.copyHtmlToClipboard = async (html) => {
    try {
        const blob = new Blob([html], { type: 'text/html' });
        const data = [new ClipboardItem({
            'text/html': blob,
            'text/plain': new Blob([html], { type: 'text/plain' })
        })];
        
        await navigator.clipboard.write(data);
    } catch (err) {
        // Fallback for browsers that don't support ClipboardItem with HTML
        try {
            await navigator.clipboard.writeText(html);
        } catch (e) {
            console.error('Failed to copy to clipboard:', e);
            throw e;
        }
    }
};

window.downloadFile = (filename, base64Data) => {
    const binaryString = atob(base64Data);
    const bytes = new Uint8Array(binaryString.length);
    for (let i = 0; i < binaryString.length; i++) {
        bytes[i] = binaryString.charCodeAt(i);
    }
    
    const blob = new Blob([bytes], { type: 'application/vnd.openxmlformats-officedocument.wordprocessingml.document' });
    const url = URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.download = filename;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
    URL.revokeObjectURL(url);
};
