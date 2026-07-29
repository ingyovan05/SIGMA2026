'use client';

import { FormEvent, useState } from 'react';

const modules = [
  ['Inicio', 'Disponible en la nueva plataforma', 'Activo'],
  ['Bodega y almacén', 'Pendiente de migración', 'Próximo'],
  ['Compras', 'Pendiente de migración', 'Próximo'],
  ['Requisiciones', 'Pendiente de migración', 'Próximo'],
  ['Contratos', 'Pendiente de migración', 'Próximo'],
  ['SisControl', 'Pendiente de migración', 'Próximo'],
  ['HSE', 'Pendiente de migración', 'Próximo']
];

export default function Home() {
  const [signedIn, setSignedIn] = useState(false);

  function enter(event: FormEvent) {
    event.preventDefault();
    setSignedIn(true);
  }

  if (!signedIn) {
    return (
      <main className="login-page">
        <section className="brand-panel">
          <Logo />
          <div className="message">
            <p className="eyebrow">Nueva plataforma</p>
            <h1>El trabajo de siempre, ahora más claro y ágil.</h1>
            <p>Una experiencia renovada para gestionar materiales, recursos y operaciones.</p>
          </div>
          <div className="accent-line" />
        </section>
        <section className="form-panel">
          <form onSubmit={enter}>
            <div className="review-badge">Vista de revisión · Sin conexión a datos</div>
            <p className="eyebrow">Bienvenido</p>
            <h2>Iniciar sesión</h2>
            <p className="intro">Esta demostración no valida ni almacena las credenciales ingresadas.</p>
            <label htmlFor="user">Usuario</label>
            <input id="user" placeholder="Usuario de demostración" autoComplete="off" />
            <label htmlFor="password">Contraseña</label>
            <input id="password" type="password" placeholder="Contraseña de demostración" autoComplete="off" />
            <button type="submit">Ingresar a la demostración</button>
            <p className="help">La versión productiva utilizará la API .NET y SQL Server.</p>
          </form>
        </section>
      </main>
    );
  }

  return (
    <div className="shell">
      <aside>
        <Logo />
        <nav>
          <a className="active"><span>⌂</span> Inicio</a>
          <p>Módulos</p>
          {modules.slice(1).map(([name]) => (
            <a className="disabled" key={name}><span>□</span>{name}<small>Próximo</small></a>
          ))}
        </nav>
        <div className="aside-footer">Modernización · Fase 1</div>
      </aside>
      <main className="dashboard">
        <header>
          <div><small>Sistema Integrado de Gestión</small><strong>Panel principal</strong></div>
          <div className="user">
            <span>Y</span><div><strong>Usuario de revisión</strong><small>Vista demostrativa</small></div>
            <button onClick={() => setSignedIn(false)}>Salir</button>
          </div>
        </header>
        <section className="content">
          <div className="demo-banner">Modo revisión: no hay conexión con SQL Server ni datos reales.</div>
          <div className="welcome">
            <div><p className="eyebrow">Buen día</p><h1>Usuario de revisión</h1><p>Este es el nuevo punto de entrada a los procesos de SIGMA.</p></div>
            <div className="context"><small>Contexto</small><strong>Acceso general</strong></div>
          </div>
          <div className="section-title"><div><h2>Módulos</h2><p>La migración se habilitará progresivamente.</p></div><span>7 registrados</span></div>
          <div className="module-grid">
            {modules.map(([name, description, status], index) => (
              <article className={index === 0 ? 'available' : ''} key={name}>
                <div className="module-icon">{index + 1}</div>
                <div><h3>{name}</h3><p>{description}</p></div>
                <span className="status">{status}</span>
              </article>
            ))}
          </div>
        </section>
      </main>
    </div>
  );
}

function Logo() {
  return <div className="logo"><span>S</span><div><strong>SIGMA</strong><small>Sistema integrado de gestión</small></div></div>;
}
