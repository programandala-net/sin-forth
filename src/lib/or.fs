\ lib/or.fs
\ by Marcos Cruz (programandala.net), 2023.
\ Last modified: 20230425T1505+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require pop-hl-de.fs \ `pop-hl-de`
require push-hl.fs   \ `push-hl`

: or ( x1 x2 -- f )
  pop-hl-de \ call pop_hl_de
  e a ld,   \ ld a,e
  l or,     \ or l
  a l ld,   \ ld l,a
  d a ld,   \ ld a,d
  h or,     \ or h
  a h ld,   \ ld h,a
  push-hl ; \ jp push_hl

  \ doc{
  \
  \ or ( x1 x2 -- x3 )
  \
  \ _x3_ is the bit-by-bit inclusive-or of _x1_ with _x2_.
  \
  \ // XXX
  \ // See also: `and`, `xor`, `negate`, `0=`, `dor`.
  \ See also: `negate`.
  \
  \ }doc
