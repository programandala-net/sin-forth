\ lib/two-swap.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

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
