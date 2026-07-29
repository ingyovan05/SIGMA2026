# Identidad visual Ismocol

Esta guía aplica a todas las pantallas nuevas de SIGMA 2026. La referencia es
el portal corporativo oficial de Ismocol.

## Paleta base

| Token | Valor | Uso |
|---|---:|---|
| `--ismocol-orange` | `#F66534` | Acción primaria, indicador activo y acentos |
| `--ismocol-orange-dark` | `#D94B1E` | Hover y estados presionados |
| `--ismocol-ink` | `#231F20` | Marca, texto principal y navegación |
| `--ismocol-slate` | `#162836` | Fondos estructurales oscuros |
| `--ismocol-slate-soft` | `#374754` | Navegación secundaria |
| `--ismocol-gray` | `#736E6E` | Texto secundario |
| `--ismocol-border` | `#D8D8D8` | Bordes y divisores |
| `--ismocol-surface` | `#EEEEEE` | Fondos y tarjetas secundarias |
| `--ismocol-white` | `#FFFFFF` | Superficies principales y contraste |

## Reglas

- El naranja se reserva para acciones, selección y énfasis; no debe dominar
  grandes superficies.
- La navegación principal usa carbón o azul pizarra.
- Los fondos de trabajo deben ser blancos o gris claro.
- Estados de error, advertencia y éxito mantienen colores semánticos accesibles.
- Todo contraste de texto debe cumplir al menos WCAG AA.
- Los módulos deben consumir los tokens globales; no deben crear una paleta
  independiente.
