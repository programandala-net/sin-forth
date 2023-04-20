\ lib/defer-fetch.fs

\ This file is part of Sin Forth.

\ This file adds `defer@` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012111806.
\ See change log at the end of the file.

\ ==============================================================

require sin_forth/lib/pop-hl.fs \ `pop-hl`
require sin_forth/lib/push-de.fs \ `push-de`

get-order get-current

target-definitions

\ XXX TODO Test.

: defer@ ( dea1 -- dea2 )
  pop-hl
  h incp, \ inc hl
  m e ld, \ ld e,(hl)
  h incp, \ inc hl
  m d ld, \ ld d,(hl)
  push-de ;

  \ doc{
  \
  \ defer@ ( dea1 -- dea2 ) "defer-fetch"
  \
  \ Return the word _dea2_ currently associated to the deferred
  \ word _dea1_.
  \
  \ // XXX TODO
  \ // See also: `defer!`, `defer`, `>action`.
  \ See also: `defer!`, `defer`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-10: Start.
\
\ 2020-12-11: Add the requirements. Document.
