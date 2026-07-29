import { copyFile, writeFile } from 'node:fs/promises';

await copyFile('.next/server/app/index.html', '.open-next/assets/index.html');
await writeFile(
  '.open-next/worker.js',
  `export default {
  async fetch(request, env) {
    const url = new URL(request.url);
    if (url.pathname === "/") {
      url.pathname = "/index.html";
    }
    return env.ASSETS.fetch(new Request(url, request));
  }
};
`,
  'utf8'
);
