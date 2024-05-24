function BlazorDownloadFile(filename, content) {
    console.log('JS file loaded');
    const blob = new Blob([content], { type: 'application/octet-stream' });
    const exportUrl = URL.createObjectURL(blob);

    const a = document.createElement('a');
    document.body.appendChild(a);
    a.href = exportUrl;
    a.download = filename;
    a.target = '_self';
    a.click();

    URL.revokeObjectURL(exportUrl);
}
