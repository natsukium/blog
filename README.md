This is a [Next.js](https://nextjs.org/) project bootstrapped with [`create-next-app`](https://github.com/vercel/next.js/tree/canary/packages/create-next-app).

## Getting Started

First, run the development server:

```bash
dotnet restore
dotnet tool restore
dotnet fake build -t dev --parallel 2
```

Open [http://localhost:3000](http://localhost:3000) with your browser to see the result.

You can start editing the page by modifying `src/pages/index.fs`. The page auto-updates as you edit the file.

## Export HTML

Transpile & Trim unused CSS & Build HTML

```bash
dotnet fake build
```
