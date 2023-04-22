\ lib/zero-until.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1820+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

require backward-resolve.fs \ `<resolve`
require question-branch.fs  \ `?branch`

get-order get-current

compiler-definitions

: 0until \ Compilation: ( C: dest -- )
         \ Run-time:    ( f -- )
  ?branch compiler{ <resolve } ;

  \ doc{
  \
  \ 0until
  \   Compilation: ( C: dest -- )
  \   Run-time:    ( f -- )

  \
  \ Compilation: Compile a conditional `0branch` to the backward
  \ reference _dest_, usually left by `begin`.
  \
  \ Run-time: If _f_ is not zero, continue execution at the location
  \ specified by _dest_.

  \ // XXX TODO
  \ See also: `while`, `again`, `repeat`, `<resolve`,
  \ `-until`, `+until`.
  \
  \ }doc

set-current set-order
