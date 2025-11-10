async function loadComponent(htmlPath, cssPath, jsPath, targetSelector) {
            // 1️⃣ Carrega o HTML
            const response = await fetch(htmlPath);
            const html = await response.text();
            document.querySelector(targetSelector).innerHTML = html;

            // 2️⃣ Injeta o CSS (se ainda não estiver na página)
            if (cssPath && !document.querySelector(`link[href="${cssPath}"]`)) {
                const link = document.createElement('link');
                link.rel = 'stylesheet';
                link.href = cssPath;
                document.head.appendChild(link);
            }

            // 3️⃣ Injeta o JS
            if (jsPath) {
                const script = document.createElement('script');
                script.src = jsPath;
                document.body.appendChild(script);
            }
        }