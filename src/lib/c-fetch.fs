\ lib/c-fetch.fs
\ by Marcos Cruz (programandala.net), 2023.
\ Last modified: 20230425T0812+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require pop-hl.fs  \ `pop-hl`
require push-de.fs \ `push-de`

: c@ ( ca -- c )
  pop-hl
  m e ld, \ ld e,(hl)
  0 d ld#, \ ld d,0
  push-de ;

  \ doc{
  \
  \ c@ ( ca -- c ) "c-fetch"
  \
  \ Return the byte _c_ stored at _ca_.
  \
  \ // XXX TODO
  \ // See also: `2@`.
  \ See also: `c!`, `@`.
  \
  \ }doc
