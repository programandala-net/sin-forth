\ lib/two-swap.fs

\ This file is part of Sin Forth.

\ This file adds `2swap` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012240228.
\ See change log at the end of the file.

\ ==============================================================

require pop-hl-de.fs  \ `pop-hl-de`
require push-de-hl.fs \ `push-de-hl`

get-order get-current

target-definitions

: 2swap ( x1 x2 x3 x4 -- x3 x4 x1 x2 )
  exx,       \ exx
  pop-hl-de  \ call pop_hl_de
  exx,       \ exx
  pop-hl-de  \ call pop_hl_de
  exx,       \ exx
  push-de-hl \ call pop_de_hl
  exx,       \ exx
  push-de-hl \ call pop_de_hl
  ;          \ ret

  \ doc{
  \
  \ 2swap ( x1 x2 x3 x4 -- x3 x4 x1 x2 ) "two-swap"
  \
  \ Exchange the top two cell pairs.
  \
  \ See also: `swap`, `2over`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-24: Start.
