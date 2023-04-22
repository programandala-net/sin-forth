\ lib/s-lit.fs

\ This file is part of Sin Forth.

\ This file adds `slit` to the target.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1751+0200.

\ ==============================================================

require push-de.fs \ `push-de`
require push-hl.fs \ `push-hl`

get-order get-current

target-definitions

: slit ( -- ca len )
  h pop,   \ pop hl ; get the address of the compiled string
  m a ld,  \ ld a,(hl) ; get the length of the string
  h incp,  \ inc hl ; point to the start of the text
  push-hl  \ call push_hl ; put _ca_ on the stack
  0 d ld#, \ ld d,0
  a e ld,  \ ld e,a ; copy the length to DE
  push-de  \ call push_de ; put _len_ on the stack
  d addp,  \ add hl,de ; calculate the return address
  h push,  \ push hl ; set the new return address
  ;        \ ret

  \ doc{
  \
  \ slit ( -- ca len ) "s-lit"
  \
  \ Return the string _ca len_ that is compiled after the `call,` used
  \ to execute ``slit``. ``slit`` is the run-time behaviour compiled
  \ by `sliteral`.
  \
  \ // XXX TODO
  \ // See also: `lit`. 
  \
  \ }doc

set-current set-order
