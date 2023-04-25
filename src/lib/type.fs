\ lib/type.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230424T1521+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require after.fs   \ `after`
require count.fs   \ `count`
require drop.fs    \ `drop`
require emit.fs    \ `emit`
require for.fs     \ `for`
require step.fs    \ `step`
require then.fs    \ `then`

: type ( ca len -- )
  for after count emit then step drop ;

  \ doc{
  \
  \ type ( ca len -- )
  \
  \ If _len_ is greater than zero, display the character string
  \ _ca len_.
  \
  \ // XXX TODO
  \ // See also: `type-udg`.
  \
  \ See also: `emit`.
  \
  \ }doc
