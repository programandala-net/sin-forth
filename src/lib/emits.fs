\ lib/emits.fs

\ This file is part of Sin Forth.

\ This file adds `emits` to the target.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012260225.
\ See change log at the end of the file.

\ ==============================================================

require after.fs \ `after`
require drop.fs  \ `drop`
require dup.fs   \ `dup`
require emit.fs  \ `emit`
require for.fs   \ `for`
require step.fs  \ `step`
require then.fs  \ `then`

get-order get-current

target-definitions

: emits ( c n -- )
  for after dup emit then step drop ;

  \ Credit: code adapted from Solo Forth.

  \ doc{
  \
  \ emits ( c n -- )
  \
  \ If _n_ is greater than zero, display _n_ characters _c_.
  \
  \ See also: `emit`, `spaces`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-26: Start.
