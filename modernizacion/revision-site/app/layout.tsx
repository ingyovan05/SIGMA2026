import type { Metadata } from 'next';
import './styles.css';

export const metadata: Metadata = {
  title: 'SIGMA 2026 — Revisión',
  description: 'Vista de revisión de la modernización de SIGMA'
};

export default function RootLayout({ children }: Readonly<{ children: React.ReactNode }>) {
  return (
    <html lang="es">
      <body>{children}</body>
    </html>
  );
}
