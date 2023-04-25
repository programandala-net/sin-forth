\ lib/emits.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230425T0812+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require after.fs \ `after`
require drop.fs  \ `drop`
require dup.fs   \ `dup`
require emit.fs  \ `emit`
require for.fs   \ `for`
require step.fs  \ `step`
require then.fs  \ `then`

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
